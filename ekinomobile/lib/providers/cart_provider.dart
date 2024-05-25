import 'package:collection/collection.dart';
import 'package:ekinomobile/model/cart.dart';
import 'package:flutter/widgets.dart';

import '../model/movie.dart';

class CartProvider with ChangeNotifier {
  Cart cart = Cart();
  addToCart(Movie product) {
    if (findInCart(product) != null) {
      findInCart(product)?.count++;
    } else {
      cart.items.add(CartItem(product, 1));
    }
    
    notifyListeners();
  }

  removeFromCart(Movie product) {
    cart.items.removeWhere((item) => item.projection.movieId == product.movieId);
    notifyListeners();
  }

  CartItem? findInCart(Movie product) {
    CartItem? item = cart.items.firstWhereOrNull((item) => item.projection.movieId == product.movieId);
    return item;
  }
}