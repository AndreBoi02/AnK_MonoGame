﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProyect.Content.Code
{
    internal static class SceneManager
    {
        static List<Scenes> _scenes;
        static int _currentScene = 0;

        public static void InitializeScences()
        {
            _scenes = new List<Scenes>()
            {
                new MenuScene(),
                new CreditsScene()
            };
            foreach (Scenes scene in _scenes) 
            {
                scene.InitializeScene();
            }
        }

        public static void LoadScenesContent(Game1 game1)
        {
            foreach(Scenes scenes in _scenes)
            {
                scenes.LoadContentScene(game1);
            }
        }

        public static void UpdateScenes()
        {
            _scenes[_currentScene].UpdateScene();
        }

        public static void DrawScenes(Game1 game1)
        {
            _scenes[_currentScene].DrawScene(game1);
        }

        public static void ChangeScene(int sceneIdx )
        {
            _currentScene = sceneIdx;
        }
    }
}