import 'package:estagioja_flutter_app/home/ui/pages/home_page.dart';
import 'package:estagioja_flutter_app/shared/ui/misc/icones.dart';
import 'package:estagioja_flutter_app/vaga/ui/pages/pesquisar_vaga_page.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:mvc_pattern/mvc_pattern.dart';

class BottomNavBar extends StatefulWidget {
  const BottomNavBar({super.key});

  @override
  State createState() => _BottomNavBarState();
}

class _BottomNavBarState extends StateMVC<BottomNavBar> {

  final List<Widget> _telas = [
    const HomePage(),
    const HomePage(),
    const HomePage()
  ];

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return BottomNavigationBar(
      onTap: onTabTapped,
      items: const [
        BottomNavigationBarItem(
          icon: Icones.home,
          label: "Home",
        ),
        BottomNavigationBarItem(
          icon: Icones.vagas,
          label: "Vagas"
        ),
        BottomNavigationBarItem(
          icon: Icones.notificacoes,
          label: "Notificações"
        ),
      ],
    );
  }

  void onTabTapped(int index) {
    Navigator.push(context, MaterialPageRoute(builder: (context) => _telas[index]));
  }
}