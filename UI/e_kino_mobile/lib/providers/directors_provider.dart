import 'package:e_kino_mobile/models/directors.dart';
import 'package:e_kino_mobile/providers/base_provider.dart';

class DirectorsProvider extends BaseProvider<Director> {
  DirectorsProvider() : super("Director");

  @override
  Director fromJson(data) {
    return Director.fromJson(data);
  }
}
