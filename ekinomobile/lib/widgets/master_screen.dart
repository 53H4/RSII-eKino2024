import 'package:ekinomobile/screens/movies/movie_list_screen.dart';
import 'package:flutter/material.dart';

import '../screens/cart/cart_screen.dart';
import 'ekino_drawer.dart';

class MasterScreenWidget extends StatefulWidget {
  final Widget? child;
  const MasterScreenWidget({this.child, Key? key}) : super(key: key);

  @override
  State<MasterScreenWidget> createState() => _MasterScreenWidgetState();
}

class _MasterScreenWidgetState extends State<MasterScreenWidget> {
  int currentIndex = 0;

  void _onItemTapped(int index) {
    setState(() {
      currentIndex = index;
    });
    if (currentIndex == 0) {
      Navigator.pushNamed(context, MovieListScreen.routeName);
    } else if (currentIndex == 1) {
      Navigator.pushNamed(context, CartScreen.routeName);
    }

  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      drawer: EKinoDrawer(),
      body: SafeArea(
        child: widget.child!,
      ),
      bottomNavigationBar: BottomNavigationBar(
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(Icons.movie),
            label: 'Movies',
            
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.shopping_cart_checkout),
            label: 'Cart',
          ),
          
        ],
        
        selectedItemColor: Colors.amber[800],
        currentIndex: currentIndex,
        onTap: _onItemTapped,
      ),
      
    );
  }
}