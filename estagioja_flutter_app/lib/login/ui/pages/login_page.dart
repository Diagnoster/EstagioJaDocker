import 'package:estagioja_flutter_app/login/controller/login_controller.dart';
import 'package:estagioja_flutter_app/shared/ui/misc/icones.dart';
import 'package:flutter/material.dart';
import 'package:mvc_pattern/mvc_pattern.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

  @override
  State createState() => _LoginPageState();
}

class _LoginPageState extends StateMVC<LoginPage> {

  @override
  void initState() {
    super.initState();
    String id = add(LoginController());
    _loginController = controllerById(id) as LoginController;
  }

  LoginController? _loginController;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: SingleChildScrollView(
        child: Column(
          children: <Widget>[
            Padding(
              padding: const EdgeInsets.fromLTRB(0, 70, 0, 40),
              child: Center(
                child: Container(
                    width: 300,
                    height: 200,
                    child: Image.asset('assets/images/app_logo.png')),
              ),
            ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 25),
              child: TextField(
                controller: _loginController!.emailController,
                decoration: InputDecoration(
                  labelText: 'Login',
                  hintText: 'Digite seu Email',
                  prefixIcon: Icones.usuario,
                  errorText: _loginController!.getErroEmail()
                ),
                keyboardType: TextInputType.text,
              ),
            ),
            Padding(
              padding: const EdgeInsets.only(
                  left: 25.0, right: 25.0, top: 15, bottom: 30),
              //padding: EdgeInsets.symmetric(horizontal: 15),
              child: TextField(
                controller: _loginController!.senhaController,
                obscureText: _loginController!.isSenhaOculta,
                decoration: InputDecoration(
                  labelText: 'Senha',
                  hintText: 'Digite sua senha',
                  prefixIcon: Icones.senha,
                  suffixIcon: IconButton(onPressed: () => _loginController!.alternarVisibilidadeSenha(), icon: Icones.visualizar),
                  errorText: _loginController!.getErroSenha()
                ),
              ),
            ),

            SizedBox(
              height: 65,
              width: 360,
              child: Container(
                child: Padding(
                  padding: const EdgeInsets.only(top: 20.0),
                  child: ElevatedButton(
                    child: const Text( 'Entrar', style: TextStyle(color: Colors.white, fontSize: 20),
                    ),
                    onPressed: (){
                      _loginController!.efetuarLogin(context);
                    },
                  ),
                ),
              ),
            ),
            Visibility(
                visible: _loginController!.isEmailInvalido && _loginController!.isSenhaInvalida,
                child: const Text('Login inválido, verifique suas credenciais!',
                    style: TextStyle(color: Colors.red)),
            ),
            const SizedBox(
              height: 30,
            ),
            const Center(
              child: Text('Esqueci minha senha', style: TextStyle(fontSize: 18, color: Colors.blue),)
            ),
          ],
        ),
      ),
    );
  }

}

