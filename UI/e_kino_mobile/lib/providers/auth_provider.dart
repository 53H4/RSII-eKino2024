// import 'dart:convert';
// import 'package:spsp_mobile/models/user_auth_info.dart';
// import 'package:spsp_mobile/providers/base_provider.dart';

// class AuthProvider extends BaseProvider<UserAuthInfo> {
//   AuthProvider() : super("Auth");

//   @override
//   UserAuthInfo fromJson(data) {
//     return UserAuthInfo.fromJson(data);
//   }

//   Future<UserAuthInfo> register(dynamic request) async {
//     var url = "${BaseProvider.baseUrl}$endpoint/register";
//     var uri = Uri.parse(url);
//     var headers = createHeaders();

//     var jsonRequest = jsonEncode(request);

//     var response = await http!.post(uri, headers: headers, body: jsonRequest);
//     print(response);

//     if (isValidResponse(response)) {
//       print(response);
//       var jsonData = jsonDecode(response.body);
//       return fromJson(jsonData);
//     } else {
//       throw new Exception("Unknown error");
//     }
//   }
// }
