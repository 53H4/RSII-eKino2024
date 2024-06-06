import 'package:e_kino_mobile/models/movies.dart';
import 'package:e_kino_mobile/providers/base_provider.dart';

class MoviesProvider extends BaseProvider<Movies> {
  MoviesProvider() : super("Movie");

  @override
  Movies fromJson(data) {
    return Movies.fromJson(data);
  }
}
