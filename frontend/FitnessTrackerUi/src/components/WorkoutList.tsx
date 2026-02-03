import { useEffect, useState } from 'react'

type Exercise = {
  id: number
  name: number
  reps: number
  series: number
  weightInKg: number
}

type Workout = {
  id: number
  title: number
  exercises: Exercise[]
}

function WorkoutList() {
  const [workouts, setWorkouts] = useState<Workout[]>([])
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  async function fetchWorkouts() {
    try {
      setLoading(true)
      setError(null)

      const response = await fetch('https://localhost:7045/Workout')

      if (!response.ok) {
        throw new Error('Erro ao buscar workouts')
      }

      const data = await response.json()
      setWorkouts(data)
    } catch (err) {
      setError('Não foi possível conectar ao backend')
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => {
    fetchWorkouts()
  }, [])

  return (
    <div>
      <h2>Workouts</h2>

      <button onClick={fetchWorkouts}>Recarregar</button>

      {loading && <p>Carregando...</p>}
      {error && <p style={{ color: 'red' }}>{error}</p>}

      <ul>
        {workouts.map((workout) => (
          <li key={workout.id}>
            <strong>ID:</strong> {workout.id} |{' '}
            <strong>Title:</strong> {workout.title}
          </li>
        ))}
      </ul>
    </div>
  )
}

export default WorkoutList
