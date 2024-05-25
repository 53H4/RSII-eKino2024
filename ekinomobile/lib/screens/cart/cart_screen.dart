import 'package:ekinomobile/model/cart.dart';
import 'package:ekinomobile/providers/cart_provider.dart';
import 'package:ekinomobile/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../providers/reservation_provider.dart';
import '../../utils/util.dart';

class CartScreen extends StatefulWidget {
  static const String routeName = "/cart";

  const CartScreen({Key? key}) : super(key: key);

  @override
  State<CartScreen> createState() => _CartScreenState();
}

class _CartScreenState extends State<CartScreen> {

  late CartProvider _cartProvider;
  late ReservationProvider _orderProvider;
  
  @override
  void initState() {
    super.initState();
    
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    _cartProvider = context.watch<CartProvider>();
    _orderProvider = context.read<ReservationProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
        child: Column(
          children: [
            Expanded(child:_buildProductCardList()),
            _buildBuyButton(),
          ],
        ),
      );
  }

  Widget _buildProductCardList() {
    return ListView.builder(
      itemCount: _cartProvider.cart.items.length,
      itemBuilder: (context, index) {
        return _buildProductCard(_cartProvider.cart.items[index]);
      },
    );
  }

  Widget _buildProductCard(CartItem item) {
    return ListTile(
      leading: imageFromBase64String(item.projection.photo!),
      title: Text(item.projection.title ?? ""),
      //subtitle: Text(item.product.cijena.toString()),
      trailing: Text(item.count.toString()),
    );
  }

  Widget _buildBuyButton() {
    return TextButton(
      child: const Text("Buy"),
      onPressed: () async {
        List<Map> items = [];
        for (var item in _cartProvider.cart.items) {
          items.add({
            "projectionId": item.projection.movieId,
            "numTickets": item.count,
          });
        }
        Map order = {
          "items": items,
        };

        await _orderProvider.insert(order);

        _cartProvider.cart.items.clear();
        setState(() {
        });
      },
    );
  }
}