const Loading = (props: { visible: boolean }) => {
  if (!props.visible) {
    return <></>;
  } else {
    return <span className="p-1">now loading...</span>;
  }
};

export default Loading;
