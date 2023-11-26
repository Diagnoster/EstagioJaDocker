import 'package:estagioja_flutter_app/shared/ui/misc/icones.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:mvc_pattern/mvc_pattern.dart';

class BarraPesquisa extends StatefulWidget {
  const BarraPesquisa({super.key, required this.hintText});

  final String hintText;

  @override
  State createState() => _BarraPesquisaState();
}

class _BarraPesquisaState extends StateMVC<BarraPesquisa> {

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 10, horizontal: 15),
      child: SearchBar(
        trailing: const [IconButton(onPressed: null, icon: Icones.pesquisar)],
        hintText: widget.hintText,
      ),
    );
  }

}