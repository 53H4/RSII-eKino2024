import 'package:flutter/cupertino.dart';

import '../../widgets/master_screen.dart';

class MovieDetailsScreen extends StatefulWidget {
  static const String routeName = "/movie_details";
  final String id;
  const MovieDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<MovieDetailsScreen> createState() => _MovieDetailsScreenState();
}

class _MovieDetailsScreenState extends State<MovieDetailsScreen> {
  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Center(child: Text(widget.id),),
    );
  }
}