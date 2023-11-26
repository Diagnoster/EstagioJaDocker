import 'package:estagioja_flutter_app/home/ui/pages/home_page.dart';
import 'package:estagioja_flutter_app/shared/ui/misc/icones.dart';
import 'package:estagioja_flutter_app/shared/ui/widgets/bottom_navbar.dart';
import 'package:estagioja_flutter_app/vaga/ui/pages/pesquisar_vaga_page.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:mvc_pattern/mvc_pattern.dart';

class PageTemplate extends StatefulWidget {
  const PageTemplate({super.key, required this.body, required this.showLeadingIcon, required this.title});

  final Widget body;
  final bool showLeadingIcon;
  final String title;

  @override
  State createState() => _PageTemplateState();
}

class _PageTemplateState extends StateMVC<PageTemplate> {

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: widget.body,
      appBar: AppBar(
        title: Text(widget.title),
        centerTitle: true,
        automaticallyImplyLeading: widget.showLeadingIcon,
        iconTheme: const IconThemeData(
          color: Colors.white, //change your color here
        ),
        actions: const [
          IconButton(onPressed: null, icon: Icon(Icons.account_circle_rounded, color: Colors.white))
        ],
      ),
      bottomNavigationBar: const BottomNavBar()
    );
  }

}