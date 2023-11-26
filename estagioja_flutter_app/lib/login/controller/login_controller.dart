import 'package:estagioja_flutter_app/home/ui/pages/home_page.dart';
import 'package:estagioja_flutter_app/login/business/login_business.dart';
import 'package:estagioja_flutter_app/login/data/model/auth_request.dart';
import 'package:estagioja_flutter_app/login/data/model/auth_response.dart';
import 'package:flutter/material.dart';
import 'package:mvc_pattern/mvc_pattern.dart';

class LoginController extends ControllerMVC {

  factory LoginController() {
    _this ??= LoginController._();
    return _this!;
  }

  static LoginController? _this;
  LoginController._();
  final LoginBusiness _loginBusiness = LoginBusiness();

  bool _senhaOculta = true;
  bool _emailInvalido = false;
  bool _senhaInvalida = false;
  AuthRequest? _login;
  AuthResponse? _loginEncontrado;

  final _emailController = TextEditingController();
  final _senhaController = TextEditingController();

  static LoginController get controller => _this!;

  void alternarVisibilidadeSenha() {
    setState(() {
      _senhaOculta = !_senhaOculta;
    });
  }

  String? getErroEmail() {
    return _emailInvalido ? 'Preencha o campo Login!' : null;
  }

  String? getErroSenha() {
    return _senhaInvalida ? 'Preencha o campo Senha!' : null;
  }

  Future<void> efetuarLogin(BuildContext context) async {
    setState(() {
      _validarEmail();
      _validarSenha();
    });

    if (isEmailInvalido || isSenhaInvalida) return;

    try {
      _login = AuthRequest(_emailController.text, _senhaController.text);
      _loginEncontrado = await _loginBusiness.efetuarLogin(_login!);
      Navigator.push(context, MaterialPageRoute(builder: (context) => const HomePage()));
    } catch(e) {
      setState(() {
        _emailInvalido = true;
        _senhaInvalida = true;
      });
    }
  }

  void _validarEmail() {
    _emailController.text.isEmpty ? _emailInvalido = true : _emailInvalido = false;
  }

  void _validarSenha() {
    _senhaController.text.isEmpty ? _senhaInvalida = true : _senhaInvalida = false;
  }

  get isSenhaOculta => _senhaOculta;
  get isEmailInvalido => _emailInvalido;
  get isSenhaInvalida => _senhaInvalida;
  get emailController => _emailController;
  get senhaController => _senhaController;

}