// import 'package:flutter/material.dart';
// import 'package:spsp_mobile/models/qr_table.dart';

// class QRTablePositionsWidget extends StatelessWidget {
//   final List<QRTable> qrTableList;
//   final Function(int) onTap; // Callback function when a table is tapped

//   QRTablePositionsWidget({required this.qrTableList, required this.onTap});

//   @override
//   Widget build(BuildContext context) {
//     return Container(
//       width: MediaQuery.of(context).size.width * 0.5,
//       height: MediaQuery.of(context).size.width * 0.5,
//       child: GridView.count(
//         shrinkWrap: true,
//         physics: NeverScrollableScrollPhysics(),
//         crossAxisCount: 3,
//         children: List.generate(
//           qrTableList.length,
//           (index) {
//             bool isReserved = qrTableList[index].isReserved != null
//                 ? qrTableList[index].isReserved!
//                 : false;
//             int tableNumber = index + 1;
//             return GestureDetector(
//               onTap: () {
//                 onTap(tableNumber);
//               },
//               child: Container(
//                 decoration: BoxDecoration(
//                   color: isReserved ? Colors.red : Colors.green,
//                   borderRadius: BorderRadius.circular(120.0),
//                 ),
//                 margin: EdgeInsets.all(8.0),
//                 child: Center(
//                   child: Text(
//                     'Sto $tableNumber',
//                     style: TextStyle(
//                       color: Colors.black,
//                       fontSize: 14.0,
//                     ),
//                   ),
//                 ),
//               ),
//             );
//           },
//         ),
//       ),
//     );
//   }
// }
