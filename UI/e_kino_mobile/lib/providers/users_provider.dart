import 'package:e_kino_mobile/models/user.dart';
import 'package:e_kino_mobile/providers/base_provider.dart';

class UsersProvider extends BaseProvider<Users> {
  UsersProvider() : super("User");

  @override
  Users fromJson(data) {
    return Users.fromJson(data);
  }
}
