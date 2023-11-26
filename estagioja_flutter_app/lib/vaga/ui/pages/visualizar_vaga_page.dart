import 'package:estagioja_flutter_app/home/ui/pages/home_page.dart';
import 'package:estagioja_flutter_app/shared/ui/misc/cores.dart';
import 'package:estagioja_flutter_app/shared/ui/widgets/page_template.dart';
import 'package:estagioja_flutter_app/vaga/controller/vaga_controller.dart';
import 'package:flutter/material.dart';
import 'package:mvc_pattern/mvc_pattern.dart';

class VisualizarVagaPage extends StatefulWidget {
  const VisualizarVagaPage({super.key});

  @override
  State createState() => _VisualizarVagaPageState();
}

class _VisualizarVagaPageState extends StateMVC<VisualizarVagaPage> {

  @override
  void initState() {
    super.initState();
    String id = add(VagaController());
    _vagaController = controllerById(id) as VagaController;
  }

  VagaController? _vagaController;

  @override
  Widget build(BuildContext context) {
    return PageTemplate(
      title: 'Visualizar Vaga',
      showLeadingIcon: true,
      body: SingleChildScrollView(
        child: Card(
          margin: const EdgeInsets.symmetric(vertical: 15, horizontal: 15),
          elevation: 5,
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Padding(padding: const EdgeInsets.fromLTRB(7, 7, 10, 10),
                child: Row(
                  children: [
                    const Icon(Icons.photo_outlined, size: 60,),
                    Text(_vagaController!.vaga!.titulo, style: const TextStyle(fontSize: 24)),
                  ],
                ),
              ),
              Padding(padding: const EdgeInsets.symmetric(vertical: 0, horizontal: 15),
                child: Text("${_vagaController!.vaga!.nomeEmpresa} - Curitiba, Paraná (Presencial)", style: TextStyle(fontSize: 16),),
              ),
              Padding(padding: const EdgeInsets.symmetric(vertical: 0, horizontal: 15),
                child: Text("${_vagaController!.vaga!.quantidadeCandidaturas} Candidaturas", style: const TextStyle(fontSize: 14),),
              ),
              Padding(padding: const EdgeInsets.symmetric(vertical: 10, horizontal: 13),
                child: SizedBox(
                  width: double.infinity,
                  child: ElevatedButton(
                    onPressed: () => _vagaController!.vaga!.status == "INSCRITO" ? _confirmarDesistencia(context) : _registrarCandidatura(context),
                    style: ButtonStyle(backgroundColor:  MaterialStatePropertyAll(_vagaController!.vaga!.status == "INSCRITO" ? Cores.vermelhoGrave : Cores.roxoEstagioJa)),
                    child: Text(_vagaController!.vaga!.status == "INSCRITO" ? "Desistir" : "Candidatar", style: TextStyle(color: Colors.white, fontSize: 16),),
                  )
                ),
              ),
              Padding(padding: const EdgeInsets.symmetric(vertical: 10, horizontal: 13),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    const Padding(padding: EdgeInsets.only(bottom: 10),
                      child: Text("Sobre a Vaga", style: TextStyle(fontSize: 18)),
                    ),
                    Padding(padding: const EdgeInsets.only(bottom: 10),
                      child: Text(_vagaController!.vaga!.descricao),
                    ),
                    const Padding(padding: EdgeInsets.only(bottom: 10),
                      child:Text("Requisitos:", style: TextStyle(fontSize: 18)),
                    ),
                    Padding(padding: const EdgeInsets.only(bottom: 10),
                      child:Text("${_vagaController!.getDescricaoCursos()}\n"
                        "${_vagaController!.getDescricaoCompetencias()}"),
                    ),
                    const Padding(padding: EdgeInsets.only(bottom: 10),
                      child:Text("Responsabilidades:", style: TextStyle(fontSize: 18)),
                    ),
                    Padding(padding: const EdgeInsets.only(bottom: 10),
                      child:Text("- ${_vagaController!.vaga!.responsabilidades}"),
                    ),
                    Padding(padding: const EdgeInsets.only(bottom: 10),
                      child:Text("Bolsa: ${_vagaController!.vaga!.valorDaBolsa}0"),
                    ),
                    Padding(padding: const EdgeInsets.only(bottom: 10),
                      child:Text("Turno: ${_vagaController!.vaga!.turno.name}"),
                    ),
                    const Padding(padding: EdgeInsets.only(bottom: 10),
                        child:Text("Benefícios"),
                    ),
                    Padding(padding: const EdgeInsets.only(bottom: 10),
                      child:Text("- ${_vagaController!.vaga!.beneficios}"),
                    ),
                    const Text("Venha fazer parte do nosso time!")
                  ]
                )
              )
            ],
          ),
        ),
      )
    );
  }

  void _retirarCandidatura() async {
    await _vagaController!.retirarCandidatura(_vagaController!.vaga!.id);
  }

  void _registrarCandidatura(BuildContext context) async {
    await _vagaController!.registrarCandidatura(_vagaController!.vaga!.id);
    Navigator.push(context, MaterialPageRoute(builder: (context) => const HomePage()));
  }

  _confirmarDesistencia(BuildContext context) {
    Widget cancelButton = ElevatedButton(
      onPressed:  () => Navigator.of(context).pop(),
      style: const ButtonStyle(backgroundColor: MaterialStatePropertyAll(Colors.white),
          shadowColor: MaterialStatePropertyAll(Cores.roxoEstagioJa)),
      child: const Text("Cancelar", style: TextStyle(color: Cores.roxoEstagioJa),),
    );
    Widget continueButton = ElevatedButton(
      child: const Text("Confirmar", style: TextStyle(color: Colors.white)),
      onPressed:  () {
        _retirarCandidatura();
        Navigator.of(context).pop();
        Navigator.push(context, MaterialPageRoute(builder: (context) => const HomePage()));
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