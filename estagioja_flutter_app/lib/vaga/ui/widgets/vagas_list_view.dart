import 'dart:math';

import 'package:estagioja_flutter_app/shared/ui/misc/cores.dart';
import 'package:estagioja_flutter_app/shared/ui/misc/icones.dart';
import 'package:estagioja_flutter_app/vaga/controller/vaga_controller.dart';
import 'package:estagioja_flutter_app/vaga/data/model/vaga.dart';
import 'package:flutter/material.dart';
import 'package:mvc_pattern/mvc_pattern.dart';

class VagasListView extends StatefulWidget {
  const VagasListView({super.key});

  @override
  State createState() => _VagasListViewState();
}

class _VagasListViewState extends StateMVC<VagasListView> {

  @override
  void initState() {
    String id = add(VagaController());
    _vagaController = controllerById(id) as VagaController;
    buscarVagas();
    super.initState();
  }

  VagaController? _vagaController;
  List<Vaga> _vagas = [];
  List<Vaga> _vagasAbertas = [];

  @override
  Widget build(BuildContext context) {
    return Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          const Padding(padding: EdgeInsets.fromLTRB(15, 10, 0, 0),
            child: Text("Candidaturas Recentes", textAlign: TextAlign.left, style: TextStyle(fontSize: 24)),
          ),
          Flexible( child: ListView.builder(
          shrinkWrap: true,
          padding: const EdgeInsets.all(8),
          itemCount: _vagas.length,
          itemBuilder: (BuildContext context, int index) {
            return Padding(padding: const EdgeInsets.fromLTRB(7, 0, 10, 10),
              child: Row(
                children: [
                  const Icon(Icons.photo_outlined, size: 60,),
                  Text("${_vagas[index].titulo}\n${_vagas[index].nomeEmpresa}", style: const TextStyle(fontSize: 16)),
                  Padding(padding: const EdgeInsets.only(bottom: 22),
                      child: IconButton(onPressed: () => _vagaController!.buscarVaga(context, _vagas[index].id, "INSCRITO"),
                          icon: Icones.link)
                  ),
                  Expanded(
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.end,
                        children: [
                          ElevatedButton(
                            onPressed: () => _confirmardesistencia(context, _vagas[index].id),
                            style: const ButtonStyle(backgroundColor: MaterialStatePropertyAll(Cores.vermelhoGrave),),
                            child: const Text("Desistir", style: TextStyle(fontSize: 16, color: Colors.white),),
                          )
                        ],
                      )
                  )
                ],
              ),
            );
          }
        )),
          const Padding(padding: EdgeInsets.fromLTRB(15, 10, 0, 0),
            child: Text("Recomendações", textAlign: TextAlign.left, style: TextStyle(fontSize: 24)),
          ), Flexible(child: ListView.builder(
          shrinkWrap: true,
          padding: const EdgeInsets.all(8),
          itemCount: _vagasAbertas.length,
          itemBuilder: (BuildContext context, int index) {
            return Padding(padding: const EdgeInsets.fromLTRB(7, 0, 10, 10),
              child: Row(
                children: [
                const Icon(Icons.photo_outlined, size: 60,),
                Text("${_vagasAbertas[index].titulo}\n${_vagasAbertas[index].nomeEmpresa}", style: const TextStyle(fontSize: 16)),
                Padding(padding: const EdgeInsets.only(bottom: 22),
                  child: IconButton(onPressed: () => _vagaController!.buscarVaga(context, _vagasAbertas[index].id, "AGUARDANDO"),
                  icon: Icones.link)
                ),
                Expanded(
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.end,
                  children: [
                  ElevatedButton(
                    onPressed: () => _candidatar(_vagasAbertas[index].id),
                    style: const ButtonStyle(backgroundColor: MaterialStatePropertyAll(Cores.roxoEstagioJa),),
                    child: const Text("Candidatar", style: TextStyle(fontSize: 16, color: Colors.white),),
                )
              ],
        ))
        ],
    ));}))]);
  }

  void buscarVagas() async {
    await _vagaController!.buscarVagasPorIdCandidato();
    setState(() {
      _vagas = _vagaController!.vagas.sublist(0, min(5, _vagaController!.vagas.length));
      _vagasAbertas = _vagaController!.vagasAbertas.sublist(0, min(5, _vagaController!.vagasAbertas.length));
    });
  }

  void _retirarCandidatura(int idVaga) async {
    await _vagaController!.retirarCandidatura(idVaga);
    buscarVagas();
  }

  void _candidatar(int idVaga) async {
    await _vagaController!.registrarCandidatura(idVaga);
    buscarVagas();
  }

  _confirmardesistencia(BuildContext context, int idVaga) {
    Widget cancelButton = ElevatedButton(
      onPressed:  () => Navigator.of(context).pop(),
      style: const ButtonStyle(backgroundColor: MaterialStatePropertyAll(Colors.white),
          shadowColor: MaterialStatePropertyAll(Cores.roxoEstagioJa)),
      child: const Text("Cancelar", style: TextStyle(color: Cores.roxoEstagioJa),),
    );
    Widget continueButton = ElevatedButton(
      child: const Text("Confirmar", style: TextStyle(color: Colors.white)),
      onPressed:  () {
        _retirarCandidatura(idVaga);
        Navigator.of(context).pop();
      },
    );
    AlertDialog alert = AlertDialog(
      title: const Text("Retirar Candidatura"),
      content: const Text("Tem certeza que deseja desistir da vaga?"),
      actions: [
        cancelButton,
        continueButton,
      ],
    );
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return alert;
      },
    );
  }

}