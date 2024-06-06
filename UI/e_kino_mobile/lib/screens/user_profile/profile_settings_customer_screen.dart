// import 'package:e_kino_mobile/widgets/master_screen.dart';
// import 'package:flutter/material.dart';
// import 'package:flutter_form_builder/flutter_form_builder.dart';
// import 'package:form_builder_validators/form_builder_validators.dart';
// import 'package:provider/provider.dart';

// class ProfileSettingsCustomerScreen extends StatefulWidget {
//   // static const String routeName = "/profile-settings";

//   ProfileSettingsCustomerScreen({super.key});
//   @override
//   State<ProfileSettingsCustomerScreen> createState() => _ProfileSettingsCustomerScreenState();
// }

// class _ProfileSettingsCustomerScreenState extends State<ProfileSettingsCustomerScreen> {
//   final _formKey = GlobalKey<FormBuilderState>();
//   Map<String, dynamic> _initialValue = {};
//   late AuthProvider _authProvider;
//   late CustomerProvider _customerProvider;
//   bool isLoading = true;
//   bool formEnabled = false;
//   bool passwordVisible = false;
//   Customer? customer;

//   @override
//   void initState() {
//     super.initState();
//     _authProvider = context.read<AuthProvider>();
//     _customerProvider = context.read<CustomerProvider>();
//     initForm();
//   }

//   @override
//   void didChangeDependencies() {
//     super.didChangeDependencies();
//   }

//   Future<void> initForm() async {
//     var customerResult = await _customerProvider.getCustomerAccountInfo();

//     setState(() {
//       customer = customerResult;
//       _initialValue = {
//         'username': customerResult.userAccount!.username,
//         'email': customerResult.userAccount!.email,
//         'firstName': customerResult.userAccount!.firstName,
//         'lastName': customerResult.userAccount!.lastName,
//         'address': customerResult.address,
//         'phone': customerResult.phone,
//         'userAccountId': customerResult.userAccountId
//       };
//       isLoading = false;
//     });
//   }

//   Widget build(BuildContext context) {
//     return MasterScreenWidget(
//       title: "Vaš profil",
//       child: Column(
//         children: [
//           Expanded(
//             child: SingleChildScrollView(
//               child: isLoading
//                   ? Container(
//                       child: Center(child: CircularProgressIndicator()),
//                     )
//                   : _buildForm(),
//             ),
//           ),
//           _buildSaveButton(),
//         ],
//       ),
//     );
//   }

//   SingleChildScrollView _buildForm() {
//     return SingleChildScrollView(
//       padding: EdgeInsets.all(16.0),
//       child: FormBuilder(
//         key: _formKey,
//         initialValue: _initialValue,
//         autovalidateMode: AutovalidateMode.onUserInteraction,
//         child: Column(
//           crossAxisAlignment: CrossAxisAlignment.stretch,
//           children: [
//             FormBuilderTextField(
//               enabled: formEnabled,
//               decoration: const InputDecoration(labelText: "Ime", labelStyle: TextStyle(color: Colors.black)),
//               name: "firstName",
//               validator: FormBuilderValidators.required(errorText: "Polje ne smije biti prazno."),
//             ),
//             SizedBox(height: 10),
//             FormBuilderTextField(
//               enabled: formEnabled,
//               validator: FormBuilderValidators.required(errorText: "Polje ne smije biti prazno."),
//               decoration: const InputDecoration(
//                 labelText: "Prezime",
//                 labelStyle: TextStyle(color: Colors.black),
//               ),
//               name: "lastName",
//             ),
//             SizedBox(height: 10),
//             FormBuilderTextField(
//               enabled: false,
//               decoration: const InputDecoration(labelText: "E-mail", labelStyle: TextStyle(color: Colors.black)),
//               name: "email",
//               validator: FormBuilderValidators.email(errorText: "Unesite ispravnu e-mail adresu."),
//             ),
//             SizedBox(height: 10),
//             FormBuilderTextField(
//               enabled: false,
//               decoration:
//                   const InputDecoration(labelText: "Korisničko ime", labelStyle: TextStyle(color: Colors.black)),
//               name: "username",
//               validator: FormBuilderValidators.required(errorText: "Polje ne smije biti prazno."),
//             ),
//             SizedBox(height: 10),
//             FormBuilderTextField(
//               enabled: formEnabled,
//               decoration: const InputDecoration(labelText: "Adresa", labelStyle: TextStyle(color: Colors.black)),
//               name: "address",
//             ),
//             SizedBox(height: 10),
//             FormBuilderTextField(
//               enabled: formEnabled,
//               decoration: const InputDecoration(labelText: "Telefon", labelStyle: TextStyle(color: Colors.black)),
//               name: "phone",
//             ),
//           ],
//         ),
//       ),
//     );
//   }

//   Row _buildSaveButton() {
//     return Row(
//       mainAxisAlignment: MainAxisAlignment.end,
//       children: [
//         Padding(
//             padding: const EdgeInsets.all(10.0),
//             child: ElevatedButton(
//               child: const Text("Natrag"),
//               onPressed: () async {
//                 Navigator.pop(context);
//               },
//             )),
//         Padding(
//           padding: const EdgeInsets.all(10.0),
//           child: ElevatedButton(
//               onPressed: () async {
//                 var isValid = _formKey.currentState?.saveAndValidate() ?? false;
//                 if (formEnabled && isValid) {
//                   var request = new Map.from(_formKey.currentState!.value);
//                   request['userAccountId'] = customer!.userAccountId;

//                   try {
//                     await _customerProvider.update(customer!.id, request);

//                     setState(() {
//                       formEnabled = false;
//                     });

//                     // Navigator.pop(context);
//                     ScaffoldMessenger.of(context).showSnackBar(
//                       const SnackBar(
//                         content: Text(
//                           "Uspješno ste sačuvali izmjene",
//                           style: TextStyle(color: Colors.white),
//                         ),
//                         backgroundColor: Colors.green,
//                       ),
//                     );
//                   } on Exception catch (e) {
//                     ScaffoldMessenger.of(context).showSnackBar(
//                       SnackBar(
//                         content: Text(
//                           e.toString(),
//                           style: TextStyle(color: Colors.white),
//                         ),
//                         backgroundColor: Colors.red,
//                       ),
//                     );
//                   }
//                 } else {
//                   setState(() {
//                     formEnabled = true;
//                   });
//                 }
//               },
//               child: formEnabled ? const Text("Sačuvaj izmjene") : const Text("Uredi profil")),
//         ),
//       ],
//     );
//   }
// }
