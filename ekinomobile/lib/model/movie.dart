import 'package:json_annotation/json_annotation.dart';

part 'movie.g.dart';

@JsonSerializable()
class Movie {
  int? movieId;
  String? title;
  String? photo;


  Movie();

  factory Movie.fromJson(Map<String, dynamic> json) => _$MovieFromJson(json);

  /// Connect the generated [_$MovieToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$MovieToJson(this);
}