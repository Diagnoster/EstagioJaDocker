import 'package:estagioja_flutter_app/shared/data/model/modalidade.dart';
import 'package:estagioja_flutter_app/shared/data/model/turno.dart';

class Curso {

  Curso(this._id, this._descricao, this._modalidade, this._turno);

  int _id;
  String _descricao;
  Modalidade _modalidade;
  Turno _turno;

  int get id => _id;

  set id(int value) {
    _id = value;
  }

  String get descricao => _descricao;

  set descricao(String value) {
    _descricao = value;
  }

  Modalidade get modalidade => _modalidade;

  set modalidade(Modalidade value) {
    _modalidade = value;
  }

  Turno get turno => _turno;

  set turno(Turno value) {
    _turno = value;
  }

  Map<String, dynamic> toJson() => {
    'id': _id,
    'descricao': _descricao,
    'modalidade': modalidade.index,
    'turno': turno.index
  };

  Curso.fromJson(Map<String, dynamic> json) :
    _id = json['id'],
    _descricao = json['descricao'],
    _modalidade = Modalidade.values[json['modalidade']],
    _turno = Turno.values[json['turno']]
  ;

}