import 'package:e_kino_mobile/models/transaction.dart';
import 'package:e_kino_mobile/providers/base_provider.dart';

class TransactionProvider extends BaseProvider<Transaction> {
  TransactionProvider() : super("Transaction");

  @override
  Transaction fromJson(data) {
    return Transaction.fromJson(data);
  }
}
