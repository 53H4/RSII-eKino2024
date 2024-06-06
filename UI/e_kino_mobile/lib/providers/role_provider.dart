import 'package:e_kino_mobile/models/role.dart';
import 'package:e_kino_mobile/providers/base_provider.dart';

class RoleProvider extends BaseProvider<Role> {
  RoleProvider() : super("Role");

  @override
  Role fromJson(data) {
    return Role.fromJson(data);
  }
}
