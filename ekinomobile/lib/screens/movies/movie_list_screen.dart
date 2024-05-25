import 'package:ekinomobile/providers/movie_provider.dart';
import 'package:ekinomobile/utils/util.dart';
import 'package:ekinomobile/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../model/movie.dart';
import 'movie_details_screen.dart';

class MovieListScreen extends StatefulWidget {
  static const String routeName = "/movie";

  const MovieListScreen({Key? key}) : super(key: key);

  @override
  State<MovieListScreen> createState() => _MovieListScreenState();
}

class _MovieListScreenState extends State<MovieListScreen> {
  MovieProvider? _movieProvider;
  List<Movie> data = [];
  final TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _movieProvider = context.read<MovieProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData = await _movieProvider?.get(null);
    setState(() {
      data = tmpData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          _buildHeader(),
          _buildMovieSearch(),
          Expanded (
            child: GridView.count(
              shrinkWrap: true,
              crossAxisCount: 2,
              scrollDirection: Axis.vertical,
              children: _buildProductCardList(),
            ),
          )
        ],
      )
    );
  }

  Widget _buildHeader() {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
      child: const Text("Movies", style: TextStyle(color: Colors.grey, fontSize: 40, fontWeight: FontWeight.w600),),
    );
  }

  Widget _buildMovieSearch() {
    return Row(
      children: [
        Expanded(
          child: Container(
            padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
            child: TextField(
              controller: _searchController,
              onSubmitted: (value) async {
                var tmpData = await _movieProvider?.get({'title': value});
                setState(() {
                  data = tmpData!;
                });
              },
              decoration: InputDecoration(
                  hintText: "Search",
                  prefixIcon: const Icon(Icons.search),
                  border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(10),
                      borderSide: const BorderSide(color: Colors.grey))),
            ),
          ),
        ),
        Container(
          padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
          child: IconButton(
            icon: const Icon(Icons.filter_list),
            onPressed: () async {
                var tmpData = await _movieProvider?.get({'title': _searchController.text});
                setState(() {
                  data = tmpData!;
                });
            },
          ),
        )
      ],
    );
  }


  List<Widget> _buildProductCardList() {
    if (data.isEmpty) {
      return [const Text("Loading...")];
    }

    List<Widget> list = data
        .map((x) => Column(
          children: [
            InkWell(
              onTap: () {
                Navigator.pushNamed(context, "${MovieDetailsScreen.routeName}/${x.movieId}");
              },
              child: SizedBox(
                height: 140,
                width: 100,
                child: imageFromBase64String(x.photo!),
              ),
            ),
            const SizedBox(height: 5),
            Text(x.title ?? "",textAlign: TextAlign.center,),

            //Text(formatNumber(x.cijena)),
            /*IconButton(
              icon: Icon(Icons.shopping_cart),
              onPressed: ()  {
                  _cartProvider?.addToCart(x);
              },
            )*/
          ],
        ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
