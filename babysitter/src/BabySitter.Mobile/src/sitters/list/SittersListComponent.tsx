import * as React from 'react';
import { SitterModel } from '../models';
import { FlatList, ScrollView, Text } from 'react-native';

interface Props {
  sitters: SitterModel[];
}

export const SittersList = ({ sitters }: Props) => (
  <ScrollView>
    <FlatList
      data={sitters}
      keyExtractor={i => String(i.id)}
      renderItem={({ item }) => <Text>{`${item.lastName}, ${item.firstName}`}</Text>}
    />
  </ScrollView>
);
