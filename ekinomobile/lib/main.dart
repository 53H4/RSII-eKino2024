// ignore_for_file: must_be_immutable

import 'package:ekinomobile/providers/cart_provider.dart';
import 'package:ekinomobile/providers/reservation_provider.dart';
import 'package:ekinomobile/providers/movie_provider.dart';
import 'package:ekinomobile/screens/cart/cart_screen.dart';
import 'package:ekinomobile/screens/movies/movie_details_screen.dart';
import 'package:ekinomobile/screens/movies/movie_list_screen.dart';
import 'package:ekinomobile/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import 'providers/user_provider.dart';

void main() => runApp(MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => MovieProvider()),
        ChangeNotifierProvider(create: (_) => UserProvider()),
        ChangeNotifierProvider(create: (_) => CartProvider()),
        ChangeNotifierProvider(create: (_) => ReservationProvider()),
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: true,
        theme: ThemeData(
          // Define the default brightness and colors.
          brightness: Brightness.light,
          primaryColor: Colors.deepPurple,
          textButtonTheme: TextButtonThemeData(
              style: TextButton.styleFrom(
                  foregroundColor: Colors.deepPurple,
                  textStyle: const TextStyle(
                      fontSize: 24,
                      fontWeight: FontWeight.bold,
                      fontStyle: FontStyle.italic))),

          // Define the default `TextTheme`. Use this to specify the default
          // text styling for headlines, titles, bodies of text, and more.
          textTheme: const TextTheme(
            headline1: TextStyle(fontSize: 72.0, fontWeight: FontWeight.bold),
            headline6: TextStyle(fontSize: 36.0, fontStyle: FontStyle.italic),
          ),
        ),
        home: HomePage(),
        onGenerateRoute: (settings) {
          if (settings.name == MovieListScreen.routeName) {
            return MaterialPageRoute(
                builder: ((context) => const MovieListScreen()));
          } else if (settings.name == CartScreen.routeName) {
            return MaterialPageRoute(
                builder: ((context) => const CartScreen()));
          }

          var uri = Uri.parse(settings.name!);
          if (uri.pathSegments.length == 2 &&
              "/${uri.pathSegments.first}" == MovieDetailsScreen.routeName) {
            var id = uri.pathSegments[1];
            return MaterialPageRoute(
                builder: (context) => MovieDetailsScreen(id));
          }

          throw Exception("onGenerateRoute failed");
        },
      ),
    ));

class HomePage extends StatelessWidget {
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  late UserProvider _userProvider;

  HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    _userProvider = Provider.of<UserProvider>(context, listen: false);

    return Scaffold(
      appBar: AppBar(
        title: const Text("Welcome to eKino!"),
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              height: 400,
              decoration: const BoxDecoration(
                  image: DecorationImage(
                      image: AssetImage("assets/images/background.png"),
                      fit: BoxFit.fill)),
              child: Stack(children: [
                Positioned(
                    left: 120,
                    top: 0,
                    width: 80,
                    height: 120,
                    child: Container(
                        decoration: const BoxDecoration(
                            image: DecorationImage(
                      image: AssetImage("assets/images/light-1.png"),
                    )))),
                Positioned(
                    right: 40,
                    top: 0,
                    width: 80,
                    height: 120,
                    child: Container(
                        decoration: const BoxDecoration(
                            image: DecorationImage(
                      image: AssetImage("assets/images/clock.png"),
                    )))),
                const Center(
                    child: Text(
                  "Login",
                  style: TextStyle(
                      color: Colors.white,
                      fontSize: 40,
                      fontWeight: FontWeight.bold),
                ))
              ]),
            ),
            Padding(
              padding: const EdgeInsets.all(40),
              child: Container(
                decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(10)),
                child: Column(children: [
                  Container(
                    padding: const EdgeInsets.all(8),
                    decoration: const BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _usernameController,
                      decoration: InputDecoration(
                          border: InputBorder.none,
                          hintText: "Username",
                          hintStyle: TextStyle(color: Colors.grey[400])),
                    ),
                  ),
                  Container(
                    padding: const EdgeInsets.all(8),
                    child: TextField(
                      controller: _passwordController,
                      decoration: InputDecoration(
                          border: InputBorder.none,
                          hintText: "Password",
                          hintStyle: TextStyle(color: Colors.grey[400])),
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
              margin: const EdgeInsets.fromLTRB(40, 0, 40, 0),
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                gradient: const LinearGradient(colors: [
                  Color.fromRGBO(143, 148, 251, 1),
                  Color.fromRGBO(143, 148, 251, .6)
                ]),
              ),
              child: InkWell(
                onTap: () => login(context),
                child: const Center(child: Text("Login")),
              ),
            ),
            const SizedBox(
              height: 40,
            ),
          ],
        ),
      ),
    );
  }

  login(BuildContext context, [bool mounted = true]) async {
    try {
      Authorization.username = _usernameController.text;
      Authorization.password = _passwordController.text;

      await _userProvider.get();

      if(!mounted) return;

      Navigator.pushNamed(context, MovieListScreen.routeName);
    } catch (e) {
      showDialog(
          context: context,
          builder: (BuildContext context) => AlertDialog(
                title: const Text("Error"),
                content: Text(e.toString()),
                actions: [
                  TextButton(
                    child: const Text("Ok"),
                    onPressed: () => Navigator.pop(context),
                  )
                ],
              ));
    }
  }
}
