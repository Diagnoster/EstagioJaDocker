import 'dart:convert';

import 'package:estagioja_flutter_app/shared/utils/http_status_code.dart';
import 'package:estagioja_flutter_app/vaga/data/model/candidatura.dart';
import 'package:estagioja_flutter_app/vaga/data/model/vaga.dart';
import 'package:estagioja_flutter_app/vaga/service/vaga_service.dart';
import 'package:http/http.dart' as http;

class VagaBusiness {

  final VagaService _vagaService = VagaService();

  Future<Vaga> buscarVaga(int id) async {
    http.Response response = await _vagaService.buscarVaga(id);
    if (response.statusCode != HttpStatusCode.ok) {
      throw("Vaga $id não encontrada!");
    }
    Vaga vaga = Vaga.fromJson(jsonDecode(response.body));
    return vaga;
  }

  Future<List<Vaga>> buscarVagasPorIdCandidato(int id) async {
    http.Response response = await _vagaService.buscarVagasPorIdCandidato(id);
    if (response.statusCode != HttpStatusCode.ok) {
      throw("O estudante $id não possuí nenhuma candidatura!");
    }
    List<dynamic> vagas = jsonDecode(response.body);
    return vagas.map((vaga) => Vaga.fromJson(vaga)).toList();
  }

  Future<List<Vaga>> buscarVagasRecomendadas(int id) async {
    http.Response response = await _vagaService.buscarVagasRecomendadas(id);
    if (response.statusCode != HttpStatusCode.ok) {
      throw("Nenhuma vaga encontrada!");
    }
    List<dynamic> vagas = jsonDecode(response.body);
    return vagas.map((vaga) => Vaga.fromJson(vaga)).toList();
  }

  Future<void> retirarCandidatura(Candidatura candidatura) async {
    http.Response response = await _vagaService.retirarCandidatura(candidatura);
    if (response.statusCode != HttpStatusCode.ok) {
      throw("Estudante ${candidatura.idEstudante} não cadastrado na vaga ${candidatura.idVaga}!");
    }
  }

  Future<void> registrarCandidatura(Candidatura candidatura) async {
    http.Response response = await _vagaService.registrarCandidatura(candidatura);
    if (response.statusCode != HttpStatusCode.ok) {
      throw("Vaga ${candidatura.idVaga} não encontrada!");
    }
  }

}