import 'package:e_kino_mobile/models/rating.dart';
import 'package:e_kino_mobile/providers/base_provider.dart';

class RatingProvider extends BaseProvider<Rating> {
  RatingProvider() : super("Rating");

  @override
  Rating fromJson(data) {
    return Rating.fromJson(data);
  }
}
