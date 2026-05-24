using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemManager : MonoBehaviour
    {
        void Awake()
        {
        // Находим все EventSystem в сцене
        // Новый код (Unity 2020.3+)
        EventSystem[] systems = FindObjectsByType<EventSystem>(FindObjectsSortMode.None);

        // Если нас больше одного - удаляем лишние
        if (systems.Length > 1)
            {
                // Оставляем самый старый или тот, который не мы
                foreach (var system in systems)
                {
                    if (system != systems[0])
                    {
                        Destroy(system.gameObject);
                    }
                }
            }
        }
    }

