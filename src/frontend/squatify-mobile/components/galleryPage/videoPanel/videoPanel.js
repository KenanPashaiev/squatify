import { StyleSheet, SafeAreaView, View, FlatList } from 'react-native';
import { vh } from '../../../utils/units';
import VideoCell from './videoCell';

export default function VideoPanel() {

  const renderItem = ({ item }) => (
    <VideoCell video={item}></VideoCell>
  );
  
  return (
    <SafeAreaView style={styles.container}>
      <FlatList
        data={DATA}
        numColumns={3}
        keyExtractor={(item) => item.id}
        renderItem={renderItem}
      />
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 7,

    paddingVertical: 1 * vh,
    paddingHorizontal: 0.25 * vh,
  },
});



const DATA = [
  {
    id: 1,
    postedDate: "4/5/2022",
    name: "new pr",
    weight: 120,
    duration: '0:20',
    previewLink: "https://cdn.muscleandstrength.com/sites/default/files/field/image/article/strength-standards-400.jpg"
  },
  {
    id: 2,
    postedDate: "4/2/2022",
    name: "deadlift",
    weight: 140,
    duration: '0:27',
    previewLink: "https://upload.wikimedia.org/wikipedia/commons/thumb/6/63/Deadlift-phase_1.JPG/800px-Deadlift-phase_1.JPG"
  },
  {
    id: 3,
    postedDate: "3/15/2022",
    name: "asfasf",
    weight: 170,
    duration: '0:15',
    previewLink: "https://www.nerdfitness.com/wp-content/uploads/2019/06/camp-nerd-fitness-deadlift-713x476.jpg"
  },
  {
    id: 4,
    postedDate: "3/15/2022",
    name: "asfasf",
    weight: 170,
    duration: '0:57',
    previewLink: "https://www.nerdfitness.com/wp-content/uploads/2019/06/camp-nerd-fitness-deadlift-713x476.jpg"
  },
]

