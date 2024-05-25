// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'movie.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Movie _$MovieFromJson(Map<String, dynamic> json) => Movie()
  ..movieId = json['movieId'] as int?
  ..title = json['title'] as String?
  ..photo = json['photo'] as String?;

Map<String, dynamic> _$MovieToJson(Movie instance) => <String, dynamic>{
      'movieId': instance.movieId,
      'title': instance.title,
      'photo': instance.photo,
    };
