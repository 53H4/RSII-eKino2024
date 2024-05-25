import 'package:ekinomobile/model/movie.dart';
import 'package:ekinomobile/providers/base_provider.dart';

class MovieProvider extends BaseProvider<Movie> {
  MovieProvider() : super("Movie");

  @override
  Movie fromJson(data) {
    return Movie.fromJson(data);
  }
}