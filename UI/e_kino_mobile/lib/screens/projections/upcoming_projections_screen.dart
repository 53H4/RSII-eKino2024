import 'package:e_kino_mobile/models/movies.dart';
import 'package:e_kino_mobile/models/projection.dart';
import 'package:e_kino_mobile/models/search_result.dart';
import 'package:e_kino_mobile/providers/projections_provider.dart';
import 'package:e_kino_mobile/screens/projections/projection_details_screen.dart';
import 'package:e_kino_mobile/utils/util.dart';
import 'package:e_kino_mobile/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:intl/intl.dart';

class UpcomingProjectionsScreen extends StatefulWidget {
  const UpcomingProjectionsScreen({Key? key}) : super(key: key);

  @override
  _UpcomingProjectionsScreenState createState() => _UpcomingProjectionsScreenState();
}

class _UpcomingProjectionsScreenState extends State<UpcomingProjectionsScreen> {
  late ProjectionsProvider _projectionsProvider;
  SearchResult<Projection>? _projections;

  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _projectionsProvider = context.read<ProjectionsProvider>();
    _loadProjections();
  }

  @override
  void dispose() {
    _searchController.dispose();
    super.dispose();
  }

  Future<void> _loadProjections() async {
    var data = await _projectionsProvider.get(filter: {});

    setState(() {
      _projections = data;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title: "Projekcije",
      child: Column(
        children: [
          _createDataListView(),
        ],
      ),
    );
  }

  Widget _createDataListView() {
    return Expanded(
      child: SingleChildScrollView(
        child: Column(
          children: (_projections?.result.isNotEmpty ?? false)
              ? [
                  for (int index = 0; index < (_projections?.result.length ?? 0); index++) _createCard(index),
                ]
              : [const Center(child: Text("Učitavanje podataka..."))],
        ),
      ),
    );
  }

  Widget _createCard(int index) {
    final Projection projection = _projections!.result[index];
    final Movies? movieDetails = projection.movie;

    if (projection.dateOfProjection.isBefore(DateTime.now())) {
      return Container();
    }

    return GestureDetector(
      onTap: () {
        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => ProjectionDetailsScreen(
              projection: projection,
            ),
          ),
        );
      },
      child: Card(
        color: const Color.fromARGB(122, 152, 202, 224),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            const SizedBox(height: 48),
            Container(
              width: double.infinity,
              height: 300,
              child: imageFromBase64String(movieDetails?.photo ?? ""),
            ),
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Text(
                "${movieDetails?.title}",
                textAlign: TextAlign.center,
                style: const TextStyle(
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Text(
                DateFormat('yyyy-MM-dd HH:mm').format(projection.dateOfProjection),
                textAlign: TextAlign.center,
                style: const TextStyle(
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Text(
                "${movieDetails?.description}",
                maxLines: 2,
                overflow: TextOverflow.ellipsis,
                style: const TextStyle(
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Text(
                "Trajanje: ${movieDetails?.runningTime}",
                style: const TextStyle(
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            const SizedBox(height: 48),
          ],
        ),
      ),
    );
  }
}
