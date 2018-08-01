import * as React from 'react';
import { Component } from 'react';
import { View } from 'react-native';
import { SittersList } from './list/SittersListComponent';
import { SitterModel } from './models';

interface Props {
  sitters: SitterModel[];
  loadSitters: () => any;
}

export class Sitters extends Component<Props> {
  componentDidMount() {
    const { loadSitters } = this.props;
    loadSitters();
  }
  render() {
    const { sitters } = this.props;
    return (
      <View testID="sitters-screen">
        <SittersList sitters={sitters} />
      </View>
    );
  }
}
