 InvestigationGame

**InvestigationGame** is a console-based detective game where the player tries to capture an Iranian agent by attaching appropriate sensors based on hidden weaknesses. 
Each agent has a rank and weaknesses that the player must discover and match using the correct tools.

---

 Program Flow

1. **`Program.cs`**
   - Entry point of the application.
   - Initializes key components:
     - `LogicManager`: Responsible for evaluating sensor-weakness matches.
     - `HandleVisitor`: Implements the Visitor design pattern.
     - `ManagerAgent`: Manages agent creation and game startup.

2. **`ManagerAgent`**
   - Handles agent creation based on user input.
   - Asks the user to select an agent rank (`EnumTypeRank`).
   - Creates the agent via the `AgentFactory`.
   - Instantiates `InvestigationManager` with the chosen agent, `LogicManager`, and `HandleVisitor`.
   - Starts the gameplay loop by calling `manager.Game()`.

3. **`InvestigationManager`**
   - Manages the core gameplay:
     - Sensor selection and attachment.
     - Triggering the agent's reaction via the `Visitor`.
     - Displaying feedback from the sensor's activation.
     - Checking win/lose conditions.
   - If all weaknesses are matched — player wins.
   - If the player runs out of attempts — game over.

4. **`IranianAgent`**
   - Represents the enemy agent.
   - Contains:
     - Agent rank.
     - List of weaknesses (sensor types).
     - List of attached sensors.
     - Ability to accept visitors and process logic.

5. **`Sensor` (abstract base class)**
   - Defines sensor behavior.
   - Each concrete sensor implements `Activate(IranianAgent agent)`, returning an `ActivateResult`.
   - Some sensors may "break" if not suitable (and be removed).

6. **`LogicManager`**
   - Calculates how many attached sensors match the agent’s weaknesses.

7. **`HandleVisitor`**
   - Applies actions on the agent using the Visitor pattern.

---

 Design Principles

This project applies several SOLID principles and best practices:

- **Single Responsibility** – Each class has one clear responsibility.
- **Dependency Injection** – Objects like `LogicManager` and `HandleVisitor` are passed in via constructors.
- **Open/Closed Principle** – You can easily add new sensors or agent ranks without modifying existing logic.
- **Factory Pattern** – Centralized creation of agents and sensors via `AgentFactory` and `SensorFactory`.

---

Enumerations

- `EnumTypeRank`: Represents agent ranks like `FootSoldier`, `SquadLeader`, `SeniorCommander`, `OrganizationLeader`.
- `EnumTypeSensor`: Types of sensors such as `AudioSensor`, `ThermalSensor`, `PulseSensor`, etc.

-
