import 'package:estagioja_flutter_app/login/data/model/perfil_acesso.dart';

class AuthResponse {

  int _id;
  String _email;
  PerfilAcesso _tipoPerfil;

  AuthResponse(this._id, this._email, this._tipoPerfil);

  int get id => _id;

  set id(int value) {
    _id = value;
  }

  String get email => _email;

  set email(String value) {
    _email = value;
  }

  PerfilAcesso get tipoPerfil => _tipoPerfil;

  set tipoPerfil(PerfilAcesso value) {
    _tipoPerfil = value;
  }

  Map<String, dynamic> toJson() => {
    'id': _id,
    'email': _email,
    'tipoPerfil': _tipoPerfil
  };

  AuthResponse.fromJson(Map<String, dynamic> json) :
    _id = json['id'] ?? json['id'],
    _email = json['email'] ?? json['email'],
    _tipoPerfil = PerfilAcesso.values[json['perfil']]
  ;

}