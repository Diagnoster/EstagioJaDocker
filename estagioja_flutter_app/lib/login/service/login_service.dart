import 'dart:convert';

import 'package:estagioja_flutter_app/login/data/model/auth_request.dart';
import 'package:http/http.dart' as http;

class LoginService {

  static const String _apiUrl = 'https://estagiojaapi.azurewebsites.net/auth/logar';
  static const Map<String, String> _headers = {'Content-Type': 'application/json; charset=UTF-8'};

  Future<http.Response> efetuarLogin(AuthRequest login) async {
    return http.post(
      Uri.parse(_apiUrl),
      headers: _headers,
      body: jsonEncode(login)
    );
  }

}