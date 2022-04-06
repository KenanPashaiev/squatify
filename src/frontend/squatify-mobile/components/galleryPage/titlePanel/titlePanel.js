import { StyleSheet, View, TextInput } from 'react-native';
import { forgroundColor } from '../../../utils/colors';
import { vh } from '../../../utils/units';
import FilterButton from './filterButton';
import GalleryTitle from './galleryTitle';
import SearchBar from './searchBar';
import SortButton from './sortButton';

export default function TitlePanel() {
  return (
    <View style={styles.container}>
      <View style={styles.row}>
        <GalleryTitle></GalleryTitle>
      </View>
      <View style={styles.row}>
        <FilterButton></FilterButton>
        <SearchBar></SearchBar>
        <SortButton></SortButton>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,

    backgroundColor: forgroundColor,
    paddingTop: 4 * vh,
    paddingBottom: 1 * vh,
    paddingLeft: 3 * vh,
    paddingRight: 3.5 * vh,

    borderBottomLeftRadius: 2 * vh,
    borderBottomRightRadius: 2 * vh
  },
  row: {
    flex: 1,
    flexDirection: 'row',
    alignItems: 'center',
    
  },
});
