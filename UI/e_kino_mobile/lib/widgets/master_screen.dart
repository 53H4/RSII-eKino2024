// ignore_for_file: prefer_const_constructors

import 'package:e_kino_mobile/main.dart';
import 'package:e_kino_mobile/screens/user_profile/profile_settings_customer_screen.dart';
import 'package:e_kino_mobile/utils/util.dart';
import 'package:flutter/material.dart';

class MasterScreenWidget extends StatefulWidget {
  String? title;
  Widget? titleWidget;
  Widget? child;
  MasterScreenWidget({this.title, this.child, this.titleWidget, super.key});

  @override
  State<MasterScreenWidget> createState() => _MasterScreenWidgetState();
}

class _MasterScreenWidgetState extends State<MasterScreenWidget> {
  int currentIndex = 0;

  void _onItemTapped(int index) async {
    setState(() {
      currentIndex = index;
    });
    if (currentIndex == 0) {
      // Navigator.of(context).push(MaterialPageRoute(
      //   builder: (context) => const UpcomingProjectionsScreen(),
      // ));
    } else if (currentIndex == 1) {
      // Navigator.of(context).push(MaterialPageRoute(
      //   builder: (context) => const ReservationsListScreen(),
      // ));
    } else if (currentIndex == 2) {
      // Navigator.of(context).push(MaterialPageRoute(
      //   builder: (context) => const RatingsListScreen(),
      // ));
    } else if (currentIndex == 3) {
      // Navigator.of(context).push(MaterialPageRoute(
      //   builder: (context) => ProfileSettingsCustomerScreen(),
      // ));
    } else if (currentIndex == 4) {
      Authorization.username = "";
      Authorization.password = "";
      Navigator.push(
        context,
        MaterialPageRoute(
          builder: (context) => LoginPage(),
        ),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: widget.titleWidget ?? Text(widget.title ?? "")),
      body: widget.child!,
      bottomNavigationBar: BottomNavigationBar(
        type: BottomNavigationBarType.fixed,
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(Icons.movie),
            label: 'Projekcije',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.table_bar),
            label: 'Rezervacije',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.reviews),
            label: 'Moje ocjene',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.settings),
            label: 'Profil',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.logout),
            label: 'Odjava',
          ),
        ],
        selectedItemColor: Colors.amber[800],
        currentIndex: currentIndex,
        onTap: _onItemTapped,
      ),
    );
  }
}
