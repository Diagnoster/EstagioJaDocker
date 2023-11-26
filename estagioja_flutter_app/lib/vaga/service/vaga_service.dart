import 'dart:convert';

import 'package:estagioja_flutter_app/vaga/data/model/candidatura.dart';
import 'package:http/http.dart' as http;

class VagaService {

  static const String _apiUrl = 'https://estagiojaapi.azurewebsites.net/vaga';
  static const Map<String, String> _headers = {'Content-Type': 'application/json; charset=UTF-8'};

  Future<http.Response> buscarVaga(int id) async {
    return http.get(
        Uri.parse("$_apiUrl/visualizar-vaga/$id"),
        headers: _headers,
    );
  }

  Future<http.Response> buscarVagasPorIdCandidato(int id) async {
    return http.get(
      Uri.parse("$_apiUrl/buscar-por-candidato/$id"),
      headers: _headers,
    );
  }

  Future<http.Response> buscarVagasRecomendadas(int id) async {
    return http.get(
      Uri.parse("$_apiUrl/recomendadas/$id"),
      headers: _headers,
    );
  }

  Future<http.Response> retirarCandidatura(Candidatura candidatura) async {
    return http.post(
        Uri.parse("$_apiUrl/retirar-candidatura"),
        headers: _headers,
        body: jsonEncode(candidatura)
    );
  }

  Future<http.Response> registrarCandidatura(Candidatura candidatura) async {
    return http.post(
        Uri.parse("$_apiUrl/candidatar"),
        headers: _headers,
        body: jsonEncode(candidatura)
    );
  }

}