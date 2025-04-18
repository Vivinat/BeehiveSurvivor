# BeehiveSurvivor

BeehiveSurvivor is a .NET Console Application written in C# that simulates the lifecycle and behavior of a beehive. The project showcases realistic interactions between bees, their environment, and their survival mechanics in the context of a simulated beehive.

## Features

- **Bee Lifecycle Simulation**: Models the lifecycle of bees, including worker bees, drones, and the queen.
- **Hive Management**: Simulates hive activities like collecting resources, producing honey, and maintaining hive health.
- **Survival Mechanics**: Implements various survival challenges for the hive, including threats like predators, weather conditions, and resource scarcity.
- **Extensibility**: Designed with modular components to allow easy customization and expansion of features.

## How It Works

### System Components
1. **Bee Classes**:
   - Represents the different types of bees (worker, drone, queen) with distinct roles and behaviors.
   - Each bee type contributes to the hive's overall survival.

2. **Hive Class**:
   - Central component of the simulation, representing the beehive as a whole.
   - Manages resources, population, and hive health.

3. **Simulation Engine**:
   - Drives the simulation by updating the states of the bees and the hive in time intervals.
   - Handles random events such as weather changes or predator attacks.

4. **Console Interface**:
   - Displays the current status of the hive and allows user interaction.
   - Provides real-time feedback on hive health and simulation progress.

### Key Mechanics
- **Resource Management**: Bees collect nectar and pollen to produce honey, which is consumed to maintain the hive.
- **Population Dynamics**: The hive population changes based on birth rates, death rates, and external threats.
- **Event Handling**: Random events and scenarios affect hive survival, requiring strategic responses.

### Prerequisites
- .NET 6.0 SDK or higher installed on your system.
