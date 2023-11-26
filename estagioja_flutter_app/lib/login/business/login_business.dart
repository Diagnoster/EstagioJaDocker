import 'dart:convert';

import 'package:estagioja_flutter_app/login/data/model/auth_request.dart';
import 'package:estagioja_flutter_app/login/data/model/auth_response.dart';
import 'package:estagioja_flutter_app/login/data/model/perfil_acesso.dart';
import 'package:estagioja_flutter_app/login/service/login_service.dart';
import 'package:estagioja_flutter_app/shared/utils/cache_keys.dart';
import 'package:estagioja_flutter_app/shared/utils/http_status_code.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

class LoginBusiness {

  final LoginService _loginService = LoginService();

  Future<AuthResponse> efetuarLogin(AuthRequest login) async {
    http.Response response = await _loginService.efetuarLogin(login);
    if (response.statusCode != HttpStatusCode.ok) {
      throw("Login Inválido!");
    }

    AuthResponse usuario = AuthResponse.fromJson(jsonDecode(response.body));
    SharedPreferences cache = await SharedPreferences.getInstance();
    bool armazenado = await cache.setString(Cache.login, usuario.id.toString());

    if (!armazenado) {
      throw("Erro ao efetuar o login!");
    }
    if (usuario.tipoPerfil != PerfilAcesso.estudante) {
      throw("O perfil de acesso deve ser do tipo estudante para usar o app!");
    }

    return usuario;
  }

}