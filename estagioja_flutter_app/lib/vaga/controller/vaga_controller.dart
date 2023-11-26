import 'package:estagioja_flutter_app/shared/utils/cache_keys.dart';
import 'package:estagioja_flutter_app/vaga/business/vaga_business.dart';
import 'package:estagioja_flutter_app/vaga/data/model/candidatura.dart';
import 'package:estagioja_flutter_app/vaga/data/model/vaga.dart';
import 'package:estagioja_flutter_app/vaga/ui/pages/visualizar_vaga_page.dart';
import 'package:flutter/material.dart';
import 'package:mvc_pattern/mvc_pattern.dart';
import 'package:shared_preferences/shared_preferences.dart';

class VagaController extends ControllerMVC {

  factory VagaController() {
    _this ??= VagaController._();
    return _this!;
  }

  static VagaController? _this;
  VagaController._();
  final VagaBusiness _vagaBusiness = VagaBusiness();

  Vaga? _vaga;
  List<Vaga> _vagasCandidatadas = [];
  List<Vaga> _vagasAbertas = [];

  static VagaController get controller => _this!;

  Future<void> buscarVaga(BuildContext context, int id, String status) async {
    try {
      _vaga = await _vagaBusiness.buscarVaga(id);
      _vaga!.status = status;
      Navigator.push(context, MaterialPageRoute(builder: (context) => const VisualizarVagaPage()));
    } catch(e) {
      print(e);
    }
  }

  Future<void> buscarVagasPorIdCandidato() async {
    try {
      SharedPreferences prefs = await SharedPreferences.getInstance();
      _vagasCandidatadas = await _vagaBusiness.buscarVagasPorIdCandidato(
        int.parse(prefs.get(Cache.login) as String)
      );
      _vagasAbertas = await _vagaBusiness.buscarVagasRecomendadas(
          int.parse(prefs.get(Cache.login) as String)
      );
    } catch(e) {
      print(e);
    }
  }

  Future<void> retirarCandidatura(int idVaga) async {
    try {
      SharedPreferences prefs = await SharedPreferences.getInstance();
      Candidatura candidatura = Candidatura(
          idVaga,
          int.parse(prefs.get(Cache.login) as String)
      );
      await _vagaBusiness.retirarCandidatura(candidatura);
      vagas = await _vagaBusiness.buscarVagasPorIdCandidato(int.parse(prefs.get(Cache.login) as String));
      vagasAbertas = await _vagaBusiness.buscarVagasRecomendadas(int.parse(prefs.get(Cache.login) as String));
      setState(() {
        _vagasCandidatadas = vagas;
        _vagasAbertas = vagasAbertas;
      });
    } catch(e) {
      print(e);
    }
  }

  Future<void> registrarCandidatura(int idVaga) async {
    try {
      SharedPreferences prefs = await SharedPreferences.getInstance();
      Candidatura candidatura = Candidatura(
          idVaga,
          int.parse(prefs.get(Cache.login) as String)
      );
      await _vagaBusiness.registrarCandidatura(candidatura);
      vagas = await _vagaBusiness.buscarVagasPorIdCandidato(int.parse(prefs.get(Cache.login) as String));
      vagasAbertas = await _vagaBusiness.buscarVagasRecomendadas(int.parse(prefs.get(Cache.login) as String));
      setState(() {
        _vagasCandidatadas = vagas;
        _vagasAbertas = vagasAbertas;
      });
    } catch(e) {
      print(e);
    }
  }

  Vaga? get vaga => _vaga;

  set vaga(Vaga? value) {
    _vaga = value;
  }

  List<Vaga> get vagas => _vagasCandidatadas;

  set vagas(List<Vaga> value) {
    _vagasCandidatadas = value;
  }

  List<Vaga> get vagasAbertas => _vagasAbertas;

  set vagasAbertas(List<Vaga> value) {
    _vagasAbertas = value;
  }

  String getDescricaoCursos() {
    String detalhesCursos = '- Cursando:';
    _vaga!.cursos.forEach((curso) => detalhesCursos += '  ${curso.descricao}; ');
    return detalhesCursos;
  }

  String getDescricaoCompetencias() {
    String detalhesCompetencias = '';
    _vaga!.requisitos.forEach((requisito) => detalhesCompetencias += '- ${requisito.descricao};\n');
    return detalhesCompetencias;
  }

}