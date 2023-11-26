import 'dart:io';

import 'package:estagioja_flutter_app/login/ui/pages/login_page.dart';
import 'package:estagioja_flutter_app/shared/ui/misc/cores.dart';
import 'package:flutter/material.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  HttpOverrides.global = MyHttpOverrides();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Estagio Já',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
          seedColor: Cores.roxoEstagioJa,
          primary: Cores.roxoEstagioJa,
          secondary: Cores.roxoEstagioJa,
        ),
        appBarTheme: const AppBarTheme(
            color: Cores.roxoEstagioJa,
            titleTextStyle: TextStyle(
              color: Colors.white,
              fontSize: 22,
            ),
        ),
        elevatedButtonTheme: ElevatedButtonThemeData(
          style: ElevatedButton.styleFrom(
            backgroundColor: Cores.roxoEstagioJa,
          ),
        ),
        bottomNavigationBarTheme: const BottomNavigationBarThemeData(
          backgroundColor: Cores.roxoEstagioJa,
          unselectedItemColor: Colors.white,
          selectedItemColor: Colors.white,
        ),
      ),
      home: const LoginPage(),
    );
  }
}

class MyHttpOverrides extends HttpOverrides{
  @override
  HttpClient createHttpClient(SecurityContext? context){
    return super.createHttpClient(context)
      ..badCertificateCallback = (X509Certificate cert, String host, int port)=> true;
  }
}

