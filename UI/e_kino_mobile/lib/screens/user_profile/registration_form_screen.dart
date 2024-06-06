import 'package:e_kino_mobile/providers/users_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class RegistrationScreenScreen extends StatefulWidget {
  RegistrationScreenScreen({super.key});
  @override
  State<RegistrationScreenScreen> createState() => _RegistrationScreenScreenState();
}

class _RegistrationScreenScreenState extends State<RegistrationScreenScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  late UsersProvider _usersProvider;

  @override
  void initState() {
    super.initState();
    _usersProvider = context.read<UsersProvider>();
    initForm();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
  }

  Future<void> initForm() async {}

  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Registracija")),
      body: SingleChildScrollView(
        child: Column(
          children: [
            _buildForm(),
            Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                Padding(
                  padding: const EdgeInsets.all(10.0),
                  child: ElevatedButton(
                      onPressed: () async {
                        var isValid = _formKey.currentState?.saveAndValidate() ?? false;
                        if (isValid) {
                          var request = new Map.from(_formKey.currentState!.value);
                          request['status'] = true;
                          try {
                            await _usersProvider.insert(request);

                            Navigator.pop(context);
                            ScaffoldMessenger.of(context).showSnackBar(
                              const SnackBar(
                                content: Text(
                                  "Uspješno ste kreirali račun",
                                  style: TextStyle(color: Colors.white),
                                ),
                                backgroundColor: Colors.green,
                              ),
                            );
                          } on Exception catch (e) {
                            ScaffoldMessenger.of(context).showSnackBar(
                              SnackBar(
                                content: Text(
                                  e.toString(),
                                  style: TextStyle(color: Colors.white),
                                ),
                                backgroundColor: Colors.red,
                              ),
                            );
                          }
                        }
                      },
                      child: const Text("Kreiraj račun")),
                )
              ],
            ),
          ],
        ),
      ),
    );
  }

  SingleChildScrollView _buildForm() {
    return SingleChildScrollView(
      padding: EdgeInsets.all(16.0),
      child: FormBuilder(
        key: _formKey,
        initialValue: _initialValue,
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            FormBuilderTextField(
              decoration: const InputDecoration(labelText: "Ime", labelStyle: TextStyle(color: Colors.black)),
              name: "firstName",
              style: const TextStyle(color: Colors.black),
              validator: FormBuilderValidators.required(errorText: "Polje ne smije biti prazno."),
            ),
            SizedBox(height: 10),
            FormBuilderTextField(
              decoration: InputDecoration(
                labelText: "Prezime",
                labelStyle: TextStyle(color: Colors.black),
              ),
              name: "lastName",
              style: TextStyle(color: Colors.black),
              validator: FormBuilderValidators.required(errorText: "Polje ne smije biti prazno."),
            ),
            SizedBox(height: 10),
            FormBuilderTextField(
              decoration: const InputDecoration(labelText: "E-mail", labelStyle: TextStyle(color: Colors.black)),
              name: "email",
              style: const TextStyle(color: Colors.black),
              validator: FormBuilderValidators.compose([
                FormBuilderValidators.required(errorText: "Polje ne smije biti prazno."),
                FormBuilderValidators.email(errorText: "Unesite ispravnu email adresu."),
              ]),
            ),
            SizedBox(height: 10),
            FormBuilderTextField(
              decoration: const InputDecoration(labelText: "Telefon", labelStyle: TextStyle(color: Colors.black)),
              name: "phone",
              style: const TextStyle(color: Colors.black),
              validator: FormBuilderValidators.compose([
                FormBuilderValidators.required(errorText: "Polje ne smije biti prazno."),
              ]),
            ),
            SizedBox(height: 10),
            FormBuilderTextField(
              decoration:
                  const InputDecoration(labelText: "Korisničko ime", labelStyle: TextStyle(color: Colors.black)),
              name: "username",
              style: const TextStyle(color: Colors.black),
              validator: FormBuilderValidators.required(errorText: "Polje ne smije biti prazno."),
            ),
            SizedBox(height: 10),
            FormBuilderTextField(
              decoration: const InputDecoration(labelText: "Lozinka", labelStyle: TextStyle(color: Colors.black)),
              name: "password",
              obscureText: true,
              style: const TextStyle(color: Colors.black),
              validator: FormBuilderValidators.required(errorText: "Polje ne smije biti prazno."),
            ),
            SizedBox(height: 10),
            FormBuilderTextField(
                decoration:
                    const InputDecoration(labelText: "Ponovite lozinku", labelStyle: TextStyle(color: Colors.black)),
                name: "passwordConfirm",
                validator: FormBuilderValidators.compose([
                  FormBuilderValidators.required(errorText: "Polje ne smije biti prazno."),
                  (passwordConfirmValue) {
                    var password = _formKey.currentState?.fields["password"]!.value;
                    if (passwordConfirmValue == password) return null;
                    return 'Lozinke se ne podudaraju';
                  },
                ]),
                obscureText: true,
                style: const TextStyle(color: Colors.black)),
          ],
        ),
      ),
    );
  }
}
