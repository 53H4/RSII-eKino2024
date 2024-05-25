// ignore_for_file: must_be_immutable

import 'package:ekinomobile/providers/cart_provider.dart';
import 'package:ekinomobile/screens/movies/movie_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../screens/cart/cart_screen.dart';

class EKinoDrawer extends StatelessWidget {
  EKinoDrawer({Key? key}) : super(key: key);
  CartProvider? _cartProvider;
  @override
  Widget build(BuildContext context) {
    _cartProvider = context.watch<CartProvider>();
    return Drawer(
      child: ListView(
        children: [

          ListTile(
            title: const Text('Movies'),
            onTap: () {

              Navigator.popAndPushNamed(context, MovieListScreen.routeName);
            },
          ),
          ListTile(
            title: Text('Cart (${_cartProvider?.cart.items.length})'),
            onTap: () {
               Navigator.pushNamed(context, CartScreen.routeName);
            },
          ),
          ListTile(
            title: const Text('Reservations'),
            onTap: () {

              Navigator.popAndPushNamed(context, MovieListScreen.routeName);
            },
          ),
          ListTile(
            title: const Text('Recommendations'),
            onTap: () {

              Navigator.popAndPushNamed(context, "/recommendation");
            },
          ),
        ],
      ),
    );
  }
}