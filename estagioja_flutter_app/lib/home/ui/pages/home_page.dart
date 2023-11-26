import 'package:estagioja_flutter_app/shared/ui/widgets/search_bar.dart';
import 'package:estagioja_flutter_app/vaga/ui/widgets/vagas_list_view.dart';
import 'package:estagioja_flutter_app/shared/ui/misc/cores.dart';
import 'package:estagioja_flutter_app/shared/ui/widgets/page_template.dart';
import 'package:estagioja_flutter_app/vaga/controller/vaga_controller.dart';
import 'package:flutter/material.dart';
import 'package:mvc_pattern/mvc_pattern.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State createState() => _HomePageState();
}

class _HomePageState extends StateMVC<HomePage> {

  @override
  void initState() {
    String id = add(VagaController());
    _vagaController = controllerById(id) as VagaController;
    _vagaController!.buscarVagasPorIdCandidato();
    super.initState();
  }

  VagaController? _vagaController;

  @override
  Widget build(BuildContext context) {
    return const PageTemplate(showLeadingIcon: false, title: 'Home', body: SingleChildScrollView(
        child: Column(
          children: <Widget>[
            Padding(
              padding: EdgeInsets.symmetric(vertical: 20, horizontal: 0),
              child: Text("Bem Vindo(a)!\nFulano de Tal", style: TextStyle(fontSize: 26, fontWeight: FontWeight.bold))
            ),
            Text("Encontre a sua oportunidade perfeita!", style: TextStyle(fontSize: 22)),
            Card(
              color: Cores.roxoEstagioJa,
              elevation: 5,
              margin: EdgeInsets.all(15),
              child: Column(
                children: [
                  Padding(padding: EdgeInsets.only(top: 10),
                    child: Text("Dica do dia", style: TextStyle(color: Colors.white, fontSize: 22)),
                  ),
                  Padding(padding: EdgeInsets.only(bottom: 10),
                    child: Text("Fazer cursos em sua area ajudam a destacar seu perfil.",
                    style: TextStyle(color: Colors.white, fontSize: 22),
                    textAlign: TextAlign.center,)
                  ),
                ],
              ),
            ),
            Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  VagasListView()
                ],
              ),
          ],
        ),
      ),
    );
  }

}