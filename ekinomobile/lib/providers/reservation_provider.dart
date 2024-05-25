import 'package:ekinomobile/providers/base_provider.dart';

import '../model/order.dart';

class ReservationProvider extends BaseProvider<Order> {
  ReservationProvider() : super("Reservation");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Order();
  }
}