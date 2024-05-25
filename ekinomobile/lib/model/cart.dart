import 'package:ekinomobile/model/movie.dart';

class Cart {
    List<CartItem> items = [];
}

class CartItem {
  CartItem(this.projection, this.count);
  late Movie projection;
  late int count;
}