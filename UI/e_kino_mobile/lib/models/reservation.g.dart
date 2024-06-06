// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'reservation.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Reservation _$ReservationFromJson(Map<String, dynamic> json) => Reservation(
      (json['reservationId'] as num?)?.toInt(),
      (json['userId'] as num?)?.toInt(),
      (json['projectionId'] as num?)?.toInt(),
      json['row'] as String?,
      json['column'] as String?,
      json['numTicket'] as String?,
    );

Map<String, dynamic> _$ReservationToJson(Reservation instance) =>
    <String, dynamic>{
      'reservationId': instance.reservationId,
      'userId': instance.userId,
      'projectionId': instance.projectionId,
      'row': instance.row,
      'column': instance.column,
      'numTicket': instance.numTicket,
    };
