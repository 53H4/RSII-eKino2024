import 'package:e_kino_mobile/models/reservation.dart';
import 'package:e_kino_mobile/models/user.dart';
import 'package:e_kino_mobile/providers/movies_provider.dart';
import 'package:e_kino_mobile/providers/projections_provider.dart';
import 'package:e_kino_mobile/providers/reservation_provider.dart';
import 'package:e_kino_mobile/providers/users_provider.dart';
import 'package:e_kino_mobile/screens/reservations/reservations_details_screen.dart';
import 'package:e_kino_mobile/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:intl/intl.dart';
import 'package:shared_preferences/shared_preferences.dart';

class ReservationsListUserScreen extends StatefulWidget {
  const ReservationsListUserScreen({Key? key}) : super(key: key);

  @override
  State<ReservationsListUserScreen> createState() => _ReservationsListUserScreenState();
}

class _ReservationsListUserScreenState extends State<ReservationsListUserScreen> {
  late ReservationProvider _reservationsProvider;
  List<Reservation>? _reservations;
  late UsersProvider _usersProvider;
  Users? _currentUser;

  String? usernameLS;

  Future<String?> _retrieveUsernameFromPrefs() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    String? usernameState = prefs.getString('usernameState');
    return usernameState;
  }

  @override
  void initState() {
    super.initState();
    _retrieveUsernameFromPrefs().then((username) {
      setState(() {
        usernameLS = username;
      });
      _usersProvider = context.read<UsersProvider>();
      _fetchData();
    });
  }

  void _fetchData() async {
    final currentUser = await _usersProvider.getUsername(usernameLS ?? "");
    _currentUser = currentUser;

    try {
      _reservationsProvider = Provider.of<ReservationProvider>(context, listen: false);

      var data;
      if (currentUser?.userId != null) {
        data = await _reservationsProvider.getByUserId(_currentUser?.userId);
      } else {
        data = null;
      }

      setState(() {
        _reservations = data?.result;
      });
    } catch (error) {
      print("Greška prilikom dohvatanja podataka: $error");
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title: "Rezervacije",
      child: Container(
        padding: EdgeInsets.all(8.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            SizedBox(height: 8.0),
            Expanded(
              child: _buildDataListView(),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildDataListView() {
    if (_reservations == null || _reservations!.isEmpty) {
      return const Center(
        child: Text(
          'Nemate rezervacija.',
          style: TextStyle(fontSize: 16.0),
        ),
      );
    } else {
      return ListView.builder(
        itemCount: _reservations!.length,
        itemBuilder: (context, index) {
          final reservation = _reservations![index];
          return Card(
            margin: EdgeInsets.symmetric(vertical: 8.0, horizontal: 16.0),
            child: ListTile(
              onTap: () {
                Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => ReservationDetailsScreen(
                    reservation: reservation,
                  ),
                ));
              },
              title: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    'R.Br: ${index + 1}',
                    style: TextStyle(fontWeight: FontWeight.bold),
                  ),
                  const SizedBox(height: 4.0),
                  Text('Sjedišta: ${reservation.row ?? 'Nepoznato'}'),
                  Text('Red: ${reservation.column ?? 'Nepoznato'}'),
                  const SizedBox(height: 4.0),
                  Text('Broj karata: ${reservation.numTickets ?? 'Nepoznato'}'),
                  const SizedBox(height: 4.0),
                  FutureBuilder<String>(
                    future: _fetchUserName(context, reservation.userId!),
                    builder: (context, snapshot) {
                      if (snapshot.connectionState == ConnectionState.waiting) {
                        return CircularProgressIndicator();
                      } else {
                        return Text('Korisnik: ${snapshot.data ?? 'Nepoznato'}');
                      }
                    },
                  ),
                  const SizedBox(height: 4.0),
                  FutureBuilder<String>(
                    future: _fetchMovieTitle(context, reservation.projectionId!),
                    builder: (context, snapshot) {
                      if (snapshot.connectionState == ConnectionState.waiting) {
                        return CircularProgressIndicator();
                      } else {
                        return Text('Film: ${snapshot.data ?? 'Nepoznato'}');
                      }
                    },
                  ),
                  const SizedBox(height: 4.0),
                  FutureBuilder<String>(
                    future: _fetchProjectionDate(context, reservation.projectionId!),
                    builder: (context, snapshot) {
                      if (snapshot.connectionState == ConnectionState.waiting) {
                        return CircularProgressIndicator();
                      } else {
                        return Text('Datum i vrijeme projekcije: ${snapshot.data ?? 'Nepoznato'}');
                      }
                    },
                  ),
                ],
              ),
            ),
          );
        },
      );
    }
  }

  Future<String> _fetchUserName(BuildContext context, int userId) async {
    try {
      final user = await Provider.of<UsersProvider>(context, listen: false).getById(userId);
      return user?.username ?? 'Nepoznato';
    } catch (e) {
      print('Greška prilikom dohvatanja korisničkog imena: $e');
      return 'Nepoznato';
    }
  }

  Future<String> _fetchMovieTitle(BuildContext context, int projectionId) async {
    try {
      final projectionProvider = Provider.of<ProjectionsProvider>(context, listen: false);
      final projection = await projectionProvider.getById(projectionId);

      if (projection != null && projection.movieId != null) {
        final movieId = projection.movieId!;
        final movieProvider = Provider.of<MoviesProvider>(context, listen: false);
        final movie = await movieProvider.getById(movieId);
        return movie?.title ?? 'Nepoznato';
      } else {
        print('Projekcija ili film ne postoje: $projectionId');
        return 'Nepoznato';
      }
    } catch (e) {
      print('Greška prilikom dohvatanja podataka: $e');
      return 'Nepoznato';
    }
  }

  Future<String> _fetchProjectionDate(BuildContext context, int projectionId) async {
    try {
      final projection = await Provider.of<ProjectionsProvider>(context, listen: false).getById(projectionId);
      if (projection != null) {
        final formattedDate = DateFormat('dd.MM.yyyy HH:mm').format(projection.dateOfProjection ?? DateTime.now());
        return formattedDate;
      } else {
        return 'Nepoznato';
      }
    } catch (e) {
      print('Greška prilikom dohvatanja datuma projekcije: $e');
      return 'Nepoznato';
    }
  }
}
