import 'package:e_kino_mobile/screens/projections/upcoming_projections_screen.dart';
import 'package:e_kino_mobile/screens/user_profile/registration_form_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:e_kino_mobile/providers/auditorium_provider.dart';
import 'package:e_kino_mobile/providers/directors_provider.dart';
import 'package:e_kino_mobile/providers/movies_provider.dart';
import 'package:e_kino_mobile/providers/projections_provider.dart';
import 'package:e_kino_mobile/providers/rating_provider.dart';
import 'package:e_kino_mobile/providers/reservation_provider.dart';
import 'package:e_kino_mobile/providers/role_provider.dart';
import 'package:e_kino_mobile/providers/transaction_provider.dart';
import 'package:e_kino_mobile/providers/users_provider.dart';
import 'package:e_kino_mobile/utils/util.dart';

void main() async {
  return runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => MoviesProvider()),
      ChangeNotifierProvider(create: (_) => DirectorsProvider()),
      ChangeNotifierProvider(create: (_) => ProjectionsProvider()),
      ChangeNotifierProvider(create: (_) => ReservationProvider()),
      ChangeNotifierProvider(create: (_) => UsersProvider()),
      ChangeNotifierProvider(create: (_) => RoleProvider()),
      ChangeNotifierProvider(create: (_) => TransactionProvider()),
      ChangeNotifierProvider(create: (_) => AuditoriumProvider()),
      ChangeNotifierProvider(create: (_) => RatingProvider()),
    ],
    child: MaterialApp(
      debugShowCheckedModeBanner: true,
      theme: ThemeData(
        brightness: Brightness.light,
        primaryColor: Colors.deepPurple,
        textButtonTheme: TextButtonThemeData(
            style: TextButton.styleFrom(
                foregroundColor: Colors.deepPurple,
                textStyle: const TextStyle(fontSize: 24, fontWeight: FontWeight.bold, fontStyle: FontStyle.italic))),
        textTheme: const TextTheme(
          displayLarge: TextStyle(fontSize: 72.0, fontWeight: FontWeight.bold),
          titleLarge: TextStyle(fontSize: 36.0, fontStyle: FontStyle.italic),
        ),
      ),
      home: LoginPage(),
    ),
  ));
}

class LoginPage extends StatelessWidget {
  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  late MoviesProvider _moviesProvider;

  @override
  Widget build(BuildContext context) {
    _moviesProvider = context.read<MoviesProvider>();
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              height: 400,
              decoration: const BoxDecoration(
                  image: DecorationImage(image: AssetImage("assets/images/background.jpg"), fit: BoxFit.fill)),
            ),
            Padding(
              padding: EdgeInsets.all(40),
              child: Container(
                decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(10)),
                child: Column(children: [
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _usernameController,
                      decoration: const InputDecoration(
                          border: InputBorder.none,
                          hintText: "Username",
                          hintStyle: TextStyle(color: const Color.fromARGB(255, 185, 163, 163))),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    child: TextField(
                      obscureText: true,
                      controller: _passwordController,
                      decoration: const InputDecoration(
                          border: InputBorder.none,
                          hintText: "Pasword",
                          hintStyle: TextStyle(color: const Color.fromARGB(255, 185, 163, 163))),
                    ),
                  ),
                ]),
              ),
            ),
            const SizedBox(
              height: 2,
            ),
            Container(
              height: 50,
              margin: EdgeInsets.fromLTRB(40, 0, 40, 0),
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                gradient:
                    const LinearGradient(colors: [Color.fromRGBO(143, 148, 251, 1), Color.fromRGBO(8, 17, 184, 0.6)]),
              ),
              child: InkWell(
                onTap: () async {
                  try {
                    Authorization.username = _usernameController.text;
                    Authorization.password = _passwordController.text;

                    await _moviesProvider.get();

                    Navigator.of(context)
                        .push(MaterialPageRoute(builder: (context) => const UpcomingProjectionsScreen()));
                  } catch (e) {
                    showDialog(
                        context: context,
                        builder: (BuildContext context) =>
                            AlertDialog(title: const Text("Error "), content: Text(e.toString()), actions: [
                              TextButton(onPressed: () => Navigator.pop(context), child: const Text("Close")),
                            ]));
                  }
                },
                child: Center(child: Text("Prijava")),
              ),
            ),
            const SizedBox(
              height: 40,
            ),
            InkWell(
              onTap: () {
                Navigator.of(context).push(MaterialPageRoute(builder: (context) => RegistrationScreenScreen()));
              },
              child: const Text(
                'Registrujte se.',
                style: TextStyle(
                  color: Colors.blue,
                  decoration: TextDecoration.underline,
                ),
              ),
            ),
            SizedBox(
              height: 40,
            ),
          ],
        ),
      ),
    );
  }
}
