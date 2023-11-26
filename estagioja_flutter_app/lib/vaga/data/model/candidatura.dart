class Candidatura {

  Candidatura(this._idVaga, this._idEstudante);

  int _idVaga;
  int _idEstudante;

  int get idVaga => _idVaga;

  set idVaga(int value) {
    _idVaga = value;
  }

  int get idEstudante => _idEstudante;

  set idEstudante(int value) {
    _idEstudante = value;
  }

  Map<String, dynamic> toJson() => {
    'idVaga': _idVaga,
    'idEstudante': _idEstudante
  };

  Candidatura.fromJson(Map<String, dynamic> json) :
    _idVaga = json['idVaga'],
    _idEstudante = json['idEstudante']
  ;

}