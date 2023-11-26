class AuthRequest {

  String _email;
  String _senha;

  AuthRequest(this._email, this._senha);

  String get email => _email;

  set email(String value) {
    _email = value;
  }

  String get senha => _senha;

  set senha(String value) {
    _senha = value;
  }

  Map<String, dynamic> toJson() => {
    'email': _email,
    'senha': _senha
  };

  AuthRequest.fromJson(Map<String, dynamic> json) :
    _email = json['email'],
    _senha = json['senha']
  ;

}