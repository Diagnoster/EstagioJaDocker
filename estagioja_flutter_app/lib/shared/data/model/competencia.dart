class Competencia {

  Competencia(this._id, this._descricao);

  int _id;
  String _descricao;

  int get id => _id;

  set id(int value) {
    _id = value;
  }

  String get descricao => _descricao;

  set descricao(String value) {
    _descricao = value;
  }

  Map<String, dynamic> toJson() => {
    'id': _id,
    'descricao': _descricao
  };

  Competencia.fromJson(Map<String, dynamic> json) :
    _id = json['id'],
    _descricao = json['descricao']
  ;

}