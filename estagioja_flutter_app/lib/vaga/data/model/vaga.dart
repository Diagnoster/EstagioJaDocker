import 'dart:convert';

import 'package:estagioja_flutter_app/shared/data/model/curso.dart';
import 'package:estagioja_flutter_app/shared/data/model/competencia.dart';
import 'package:estagioja_flutter_app/shared/data/model/modalidade.dart';
import 'package:estagioja_flutter_app/shared/data/model/turno.dart';

class Vaga {

  Vaga(this._id, this._titulo, this._descricao, this._requisitos, this._cursos,
      this._responsabilidades, this._beneficios, this._status, this._valorDaBolsa,
      this._modalidade, this._turno, this._idEmpresa, this._prazo, this._quantidadeCandidaturas,
      this._nomeEmpresa);

  int _id;
  String _titulo;
  String _descricao;
  List<Competencia> _requisitos;
  List<Curso> _cursos;
  String _responsabilidades;
  String _beneficios;
  String _status;
  double _valorDaBolsa;
  Modalidade _modalidade;
  Turno _turno;
  int _idEmpresa;
  DateTime _prazo;
  int _quantidadeCandidaturas;
  String _nomeEmpresa;

  Map<String, dynamic> toJson() => {
    'id': _id,
    'titulo': _titulo,
    'descricao': _descricao,
    'requisitos': jsonEncode(_requisitos.map((requisito) => requisito.toJson()).toList()),
    'cursos': jsonEncode(_cursos.map((curso) => curso.toJson()).toList()),
    'responsabilidade': _responsabilidades,
    'beneficios': _beneficios,
    'status': _status,
    'valorDaBolsa': _valorDaBolsa,
    'modalidade': _modalidade,
    'turno': _turno,
    'idEmpresa': _idEmpresa,
    'prazo': _prazo,
    'quantidadeCandidaturas': _quantidadeCandidaturas,
    'nomeEmpresa': _nomeEmpresa
  };

  Vaga.fromJson(Map<String, dynamic> json) :
    _id = json['id'],
    _titulo = json['titulo'],
    _descricao = json['descricao'],
    _requisitos = List<Competencia>.from((json['requisitos']).map((model) => Competencia.fromJson(model))),
    _cursos = List<Curso>.from((json['cursos']).map((model) => Curso.fromJson(model))),
    _responsabilidades = json['responsabilidades'],
    _beneficios = json['beneficios'],
    _status = json['status'],
    _valorDaBolsa = double.parse(json['valorDaBolsa'].toString()),
    _modalidade = Modalidade.values[json['modalidade']],
    _turno = Turno.values[json['turno']],
    _idEmpresa = json['idEmpresa'],
    _prazo = DateTime.parse(json['prazo']),
    _quantidadeCandidaturas = json['quantidadeCandidaturas'],
    _nomeEmpresa = json['nomeEmpresa']
  ;

  int get id => _id;

  set id(int value) {
    _id = value;
  }

  String get titulo => _titulo;

  set titulo(String value) {
    _titulo = value;
  }

  String get descricao => _descricao;

  set descricao(String value) {
    _descricao = value;
  }

  List<Competencia> get requisitos => _requisitos;

  set requisitos(List<Competencia> value) {
    _requisitos = value;
  }

  List<Curso> get cursos => _cursos;

  set cursos(List<Curso> value) {
    _cursos = value;
  }

  String get responsabilidades => _responsabilidades;

  set responsabilidades(String value) {
    _responsabilidades = value;
  }

  String get beneficios => _beneficios;

  set beneficios(String value) {
    _beneficios = value;
  }

  String get status => _status;

  set status(String value) {
    _status = value;
  }

  double get valorDaBolsa => _valorDaBolsa;

  set valorDaBolsa(double value) {
    _valorDaBolsa = value;
  }

  Modalidade get modalidade => _modalidade;

  set modalidade(Modalidade value) {
    _modalidade = value;
  }

  Turno get turno => _turno;

  set turno(Turno value) {
    _turno = value;
  }

  int get idEmpresa => _idEmpresa;

  set idEmpresa(int value) {
    _idEmpresa = value;
  }

  DateTime get prazo => _prazo;

  set prazo(DateTime value) {
    _prazo = value;
  }

  int get quantidadeCandidaturas => _quantidadeCandidaturas;

  set quantidadeCandidaturas(int value) {
    _quantidadeCandidaturas = value;
  }

  String get nomeEmpresa => _nomeEmpresa;

  set nomeEmpresa(String value) {
    _nomeEmpresa = value;
  }
}