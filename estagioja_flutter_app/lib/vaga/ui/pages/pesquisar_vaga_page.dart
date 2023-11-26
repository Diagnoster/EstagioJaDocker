import 'package:estagioja_flutter_app/shared/ui/widgets/page_template.dart';
import 'package:estagioja_flutter_app/vaga/controller/vaga_controller.dart';
import 'package:flutter/material.dart';
import 'package:mvc_pattern/mvc_pattern.dart';

class PesquisarVaga extends StatefulWidget {
  const PesquisarVaga({super.key});

  @override
  State createState() => _PesquisarVagaState();
}

class _PesquisarVagaState extends StateMVC<PesquisarVaga> {

  @override
  void initState() {
    super.initState();
    String id = add(VagaController());
    _vagaController = controllerById(id) as VagaController;
    _vagaController!.buscarVagasPorIdCandidato();
  }

  VagaController? _vagaController;

  @override
  Widget build(BuildContext context) {
    return const PageTemplate(showLeadingIcon: false, title: 'Home', body: Text('Works!')
    );
  }

}